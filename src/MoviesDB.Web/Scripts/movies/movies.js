var MOVIES = function () {
    var moviesGridName = 'MoviesGrid',
        pagingUrl = 'Home/GridPager',
        detailsUrl = 'Home/Details',
        addMovieUrl = 'Home/Create',
        editMovieUrl = 'Home/Edit',

        editMovieButtonSelector = '.edit-movie-button',
        viewMovieDetailsButtonSelector = '.view-movie-details-button',
        addMovieButtonSelector = '.add-movie-button',
        submitMovieButtonSelector = '.add-movie',

        modalSelector = '.modal',
        modalContentSelector = '.modal .modal-content',
        formSelector = modalSelector + ' form';

    $('.grid-mvc').gridmvc();
    pageGrids[moviesGridName].ajaxify({
        getData: pagingUrl,
        getPagedData: pagingUrl
    });    

    function displayModal() {
        $(modalSelector).modal();
        $('[name=ReleaseDate]').datepicker({ maxDate: new Date(), changeYear: true, dateFormat: 'dd/mm/yy', })
    }

    function displayDetailsModal() {
        var movieId = $(this).attr('data-id');
        $.get(detailsUrl, { id: movieId }, function (html) {
            $(modalContentSelector).html(html);
            displayModal();
        });
    }

    function displayAddMovieModal() {
        $.get(addMovieUrl, function (html) {
            $(modalContentSelector).html(html);
            displayModal();
        });
    }

    function displayEditMovieModal() {
        var id = $(this).attr('data-id');
        $.get(editMovieUrl, { id : id }, function (html) {
            $(modalContentSelector).html(html);
            displayModal();
        });
    }

    function submitMovie() {
        var action = $(this).attr('data-action');
        var url;
        if (action == 'add') {
            url = addMovieUrl;
        } else if (action == 'edit') {
            url = editMovieUrl;
        } else {
            return;
        }

        $(formSelector).submit(function (evt) {
            evt.preventDefault();
            var $form = $(this);
            if ($form.valid()) {
                var id = $('[name=Id]').val();
                var title = $('[name=Title]').val();
                var director = $('[name=Director]').val();
                var releaseDate = $('[name=ReleaseDate]').val();
                $.post(url, { id : id, title: title, director: director, releaseDate: releaseDate }, function (response, status, xhr) {
                    if (xhr.status != 201 && xhr.status != 202) {
                        $(modalContentSelector).html(response);
                    } else {
                        $(modalSelector).modal('hide');
                        pageGrids.MoviesGrid.refreshFullGrid();
                    }
                });
            }
        });
    }    

    $('[data-gridname=MoviesGrid]').on('click', editMovieButtonSelector, displayEditMovieModal);
    $('[data-gridname=MoviesGrid]').on('click', viewMovieDetailsButtonSelector, displayDetailsModal);
    $(addMovieButtonSelector).on('click', displayAddMovieModal);

    $(modalSelector).on('click', submitMovieButtonSelector, submitMovie)
}();