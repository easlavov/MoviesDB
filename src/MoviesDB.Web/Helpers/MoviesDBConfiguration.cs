namespace MoviesDB.Web.Helpers
{
    using System;
    using System.Configuration;

    internal class MoviesDBConfiguration : IMoviesDBConfiguration
    {
        private const int DEFAULT_GRID_PAGE_SIZE = 5;
        private const string GRID_PAGE_SIZE_SETTING_KEY = "GridPageSize";

        public MoviesDBConfiguration()
        {
            GetAndSetGridPageSize();
        }

        public int GridPageSize { get; private set; }
        
        private void GetAndSetGridPageSize()
        {
            try
            {
                string value = ConfigurationManager.AppSettings[GRID_PAGE_SIZE_SETTING_KEY];
                int pageSize;
                bool parsed = int.TryParse(value, out pageSize);
                if (parsed && pageSize > 0)
                {
                    this.GridPageSize = pageSize;
                }
                else
                {
                    this.GridPageSize = DEFAULT_GRID_PAGE_SIZE;
                }
            }
            catch (Exception)
            {
                this.GridPageSize = DEFAULT_GRID_PAGE_SIZE;
            }
            
        }
    }
}