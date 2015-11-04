namespace View.DataAccessLayer {
    public interface IDataContextFactory {
        IDataContext Create();
    }
}