var MOVIES = function () {
    var moviesGridName = 'MoviesGrid',
        pagingUrl = 'Home/GridPager',
        editMovieButtonSelector = '.edit-movie-button',
        viewMovieDetailsButtonSelector = '.view-movie-details-button',
            modalSelector = '.modal';

    $('.grid-mvc').gridmvc();
    pageGrids[moviesGridName].ajaxify({
        getData: pagingUrl,
        getPagedData: pagingUrl
    });    

    function displayModal() {
        $(modalSelector).modal();
    }

    $('[data-gridname=MoviesGrid]').on('click', editMovieButtonSelector, displayModal);
    $('[data-gridname=MoviesGrid]').on('click', viewMovieDetailsButtonSelector, displayModal)
}();