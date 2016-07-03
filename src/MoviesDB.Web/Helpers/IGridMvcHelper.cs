namespace MoviesDB.Web.Helpers
{
    using System.Linq;
    using System.Web.Mvc;

    using Grid.Mvc.Ajax.GridExtensions;

    public interface IGridMvcHelper
    {
        AjaxGrid<T> GetAjaxGrid<T>(IOrderedQueryable<T> items, int pageSize) where T : class;
        AjaxGrid<T> GetAjaxGrid<T>(IOrderedQueryable<T> items, int? page, int pageSize, int partitionSize = 10) where T : class;
        object GetGridJsonData<T>(AjaxGrid<T> grid, string gridPartialViewPath, Controller controller) where T : class;
    }
}
