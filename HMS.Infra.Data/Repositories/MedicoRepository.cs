using Dapper;
using HMS.Domain.Entities;
using HMS.Domain.Interfaces.Repositories;
using HMS.Infra.Data.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HMS.Infra.Data.Repositories
{
    public class MedicoRepository : RepositoryBase<Medico>, IMedicoRepository
    {
        public MedicoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ICollection<Medico> Disponiveis()
        {
            using (IDbConnection db = new SqlConnection(_context.Database.GetConnectionString()))
            {
                var sql = @"
                SELECT 
                    [p].[Id], 
                    [p].[CPF], 
                    [p].[Nome], 
                    [m].[Id], 
                    [m].[NumeroCRM],        
                    [m].[UsuarioId], 
                    [h0].[Id], 
                    [h0].[DataHoraFim], 
                    [h0].[DataHoraInicio], 
                    [h0].[MedicoId]
                FROM [Pessoas] AS [p]
                INNER JOIN [Medicos] AS [m] ON [p].[Id] = [m].[Id]
                INNER JOIN [HorariosDisponiveis] AS [h0] ON [m].[Id] = [h0].[MedicoId]
                WHERE [h0].[Id] NOT IN (
                    SELECT [h].[Id]
                    FROM [HorariosDisponiveis] AS [h]
                    INNER JOIN [Consultas] AS [c] ON [h].[Id] = [c].[HorarioDisponivelId]
                    WHERE [h].[MedicoId] = [m].[Id])
                ORDER BY [p].[Id]";

                var medicoDictionary = new Dictionary<int, Medico>();

                var medicos = db.Query<Medico, HorarioDisponivel, Medico>(
                    sql,
                    (medico, horario) =>
                    {
                        if (!medicoDictionary.TryGetValue(medico.Id, out var medicoEntry))
                        {
                            medicoEntry = medico;
                            medicoEntry.HorariosDisponiveis = new List<HorarioDisponivel>();
                            medicoDictionary.Add(medico.Id, medicoEntry);
                        }

                        if (horario != null)
                        {
                            medicoEntry.HorariosDisponiveis.Add(horario);
                        }
                        return medicoEntry;
                    },
                    splitOn: "Id"
                ).Distinct().ToList();

                return medicos;
            }
        }
    }
}
