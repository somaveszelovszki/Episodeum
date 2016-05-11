/**
 * This file contains the JavaScript for the search page
 * @type {Object} car Contains global information
 */

car.search = {

    eventHandlers: {
        searchSubjectSelectorChange: function(){
            var postMethod = '';
            switch ($(this).val()) {
                case 'person':
                    postMethod = createURIText('person/search');
                    break;
                case 'series':
                    postMethod = createURIText('series/search');
                    break;
                default:
                    console.log('Something went wrong :(');
                    return;
            }
            $('#searchForm').attr('action', postMethod);
            console.log($('#searchForm').attr('action', postMethod));
        }
    },


    initialize: function() {
        $('.searchSubjectSelector').change(car.search.eventHandlers.searchSubjectSelectorChange)
    }
};

$(document).ready(function(){
    car.search.initialize();
});

