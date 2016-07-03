namespace MoviesDB.Web.Helpers
{
    using System.Linq;
    using System.Web.Mvc;

    using Grid.Mvc.Ajax.GridExtensions;

    public class GridMvcHelper : IGridMvcHelper
    {
        public AjaxGrid<T> GetAjaxGrid<T>(IOrderedQueryable<T> items, int pageSize) where T : class
        {
            return this.GetAjaxGrid(items, null, pageSize);
        }

        public AjaxGrid<T> GetAjaxGrid<T>(IOrderedQueryable<T> items, int? page, int pageSize, int partitionSize = 10) where T : class
        {
            var ajaxGridFactory = new AjaxGridFactory();
            int pageValue = page.HasValue ? page.Value : 1;
            var grid = ajaxGridFactory.CreateAjaxGrid(items, pageValue, page.HasValue, partitionSize);
            grid.RenderOptions.Selectable = false;
            grid.EnablePaging = true;
            grid.Pager.PageSize = pageSize;
            var castGrid = (AjaxGrid<T>)grid;

            return castGrid;
        }

        public object GetGridJsonData<T>(AjaxGrid<T> grid, string gridPartialViewPath, Controller controller) where T : class
        {
            string html = grid.ToJson(gridPartialViewPath, controller);
            bool hasItems = grid.HasItems;
            object jsonData = new
            {
                Html = html,
                hasItems
            };

            return jsonData;
        }
    }
}