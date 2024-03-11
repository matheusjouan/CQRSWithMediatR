using CQRSWithMediatR.Domain.Entities;
using CQRSWithMediatR.Domain.Interface;
using Dapper;
using System.Data;

namespace CQRSWithMediatR.Infra.Repositories;
public class MemberDapperRepository : IMemberDapperRepository
{
    // Representa a conexão GENÉRICA com o banco de dados
    // Porém tem pacotes para provedores específicos
    private readonly IDbConnection _dbConnection;

    public MemberDapperRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<Member>> GetMembers()
    {
        string query = "SELECT * FROM Members";
        var members = await _dbConnection.QueryAsync<Member>(query);
        
        _dbConnection.Close();

        return members;
    }

    public async Task<Member> GetMemberById(int id)
    {
        string query = "SELECT * FROM Members WHERE Id = @Id";
        var member = await _dbConnection.QueryFirstOrDefaultAsync<Member>(query, new { Id = id });

        _dbConnection.Close();

        return member;
    }
}
