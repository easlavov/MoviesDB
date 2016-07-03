var MOVIES = function () {
    var moviesGridName = 'MoviesGrid';
    var pagingUrl = 'Home/GridPager';

    $('.grid-mvc').gridmvc();
    pageGrids[moviesGridName].ajaxify({
        getData: pagingUrl,
        getPagedData: pagingUrl
    });
}();