namespace View.DataAccessLayer {
    class DataContextFactory : IDataContextFactory {
        public IDataContext Create() {
            return new Entities("name=AgatDb");
        }
    }
}