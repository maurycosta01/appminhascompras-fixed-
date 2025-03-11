using appminhascompras_fixed_.Models;
using SQLite;

namespace appminhascompras_fixed_.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn; // variável de conexão com o banco de dados
        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait(); // cria a tabela de produtos
        }
        public Task<int> Insert(Produto p)
        {
            return _conn.InsertAsync(p); // insere um produto
        }
        public Task<List<Produto>> Update(Produto p) //atulizacao da lista
        {
            string sql = "UPDATE Produto SET Desscricao=?, Quantidade=?, Preco=? WHERE Id=?";
            return _conn.QueryAsync<Produto>(sql, p.Descricao,p.Quantidade ,p.preco ,p.Id);
        }
        public Task<int> Delete(int id) //deletar produto 
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }
        public Task<List<Produto>> GetAll() //pegar todos os produtos
        {
            return _conn.Table<Produto>().ToListAsync();
        }
        public Task<List<Produto>> Search(string q)
        {
            string sql = "SELECT * Produto WHERE descricao LIKE '%"+ q + "%'";
            return _conn.QueryAsync<Produto>(sql);
        }
    }
}
