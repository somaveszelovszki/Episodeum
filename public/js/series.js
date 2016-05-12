/**
 * This file contains the JavaScript for the series page
 * @external car Contains global information
 */

car.series = {

    eventHandlers: {
        editButtonClick: function(){
            $('.onView').hide();
            $('.onEdit').show();
        },

        addContributionButtonClick: function() {
            car.series.initializeContribution();
        },

        saveButtonClick: function(){

            var dataTable = $('.series-data.data-table');

            var title = dataTable.find('.title-field').val();
            if(isEmpty(title)) {
                alert("Title field is empty!");
                return;
            }

            var imdbId = dataTable.find('.imdb-id-field').val();
            if(!isImdbIdValid(imdbId)) {
                alert("IMDb id is not valid!");
                return;
            }

            car.series.updateSeriesContributions();

            var showTime = getDateFromDayOfWeek(dataTable.find('.show-day-field').val(), dataTable.find('.show-time-field').val());

            var seriesData = {
                id              :   car.seriesEditorData.series.id,
                title           :   title,
                country_id      :   dataTable.find('.country-field').val(),
                genre_id        :   dataTable.find('.genre-field').val(),
                age_limit_id    :   dataTable.find('.age-limit-field').val(),
                view_number     :   dataTable.find('.view-number-field').val(),
                is_on_program   :   dataTable.find('.is-on-program-selector-field:checked').val(),
                show_time       :   getDateStringFromDate(showTime),
                imdb_id         :   imdbId,
                contributions   :   car.seriesEditorData.series.contributions
            };

            if (!seriesData.title) {
                alert('Title has not been given!');
                return;
            }

            $.post(createURIText('series/save'), seriesData, car.series.eventHandlers.saveSuccess, 'json');
        },

        removeContributionButtonClick: function() {

            var dataIndex = $(this).attr('data-index');
            var contributionRow = $(this).closest('tr[data-index="' + dataIndex + '"]');

            car.seriesEditorData.series.contributions.forEach(function(element, index, contributions){
                if (element.dataIndex == dataIndex) {
                    car.seriesEditorData.series.contributions.splice(index, 1);
                }
            });

            contributionRow.remove();
        },

        saveSuccess: function(response){
            if(response.success) {
                document.location.href = createURIText('series/edit/' + car.seriesEditorData.series.id);
            } else {
                document.location.href = createURIText('error/index/' + (response.message ? response.message : ''));
            }
        }
    },

    updateSeriesContributions: function(){
        if (car.seriesEditorData.series.contributions.length > 0) {
            car.seriesEditorData.series.contributions.forEach(function(element, index, contributions){
                // if id is null, it means contribution has not been saved to DB yet
                if (!contributions[index].id) {
                    var dataRow = $('.contribution-list .data-table tr[data-index="' + contributions[index].dataIndex + '"]');
                    contributions[index].personId = dataRow.find('.person-select').val();
                    contributions[index].contributionId = dataRow.find('.contribution-select').val();
                }
            })
        }
    },

    initializeContribution: function(contributionObj){

        var contributionTable = $('.contribution-list .data-table');

        if (!contributionTable) {
            return;
        }

        var html;

        var indexes = [];
        contributionTable.find('tr').each(function(){
            indexes.push($(this).attr('data-index'));
        });

        var maxIndex = indexes.max();
        var index = maxIndex ? maxIndex + 1 : 1;

        if (contributionObj) {  //add existing contribution

            var person = car.seriesEditorData.persons.getElementById(contributionObj.personId);
            var contributionType = car.seriesEditorData.contributions.getElementById(contributionObj.contributionId);

            var contributionIndex = car.seriesEditorData.series.contributions.indexOf(contributionObj);

            car.seriesEditorData.series.contributions[contributionIndex].dataIndex = index;

            html = '<tr data-index="' + index + '">' +
            '<td colspan="2">' +
            '<a class="page-anchor" href="' + createURIText('person/edit/' + person.id) + '">' +
            '<b>' + person.name + '</b>' +
            '</a>' +
            '</td>' +
            '<td>' + contributionType.name + '</td>' +
            '<td class="onEdit">' +
            '<button class="remove-contribution" data-index="' + index + '">Remove</button>' +
            '</td>' +
            '</tr>';
        } else {

            var personSelect = '<select class="person-select">';
            car.seriesEditorData.persons.forEach(function(person){
                personSelect += '<option value="' + person.id + '">' + person.name + '</option>';
            });
            personSelect += '</select>';

            var contributionSelect = '<select class="contribution-select">';
            car.seriesEditorData.contributions.forEach(function(con){
                contributionSelect += '<option value="' + con.id + '">' + con.name + '</option>';
            });
            contributionSelect += '</select>';

            // add empty contribution (for new record)
            html = '<tr class="new" data-index="' + index + '">' +
            '<td colspan="2">' + personSelect + '</td>' +
            '<td>' + contributionSelect + '</td>' +
            '<td class="onEdit">' +
            '<button class="remove-contribution" data-index="' + index + '">Remove</button>' +
            '</td>' +
            '</tr>';

            car.seriesEditorData.series.contributions.push({
                'id'                :   null,
                'personId'          :   null,
                'contributionId'    :   null,
                'dataIndex'         :   index
            })
        }

        contributionTable.append(html);
        $('button.remove-contribution').off().click(car.series.eventHandlers.removeContributionButtonClick);
    },

    initializeContributions: function() {
        if(car.seriesEditorData.series && car.seriesEditorData.series.contributions) {
            car.seriesEditorData.series.contributions.forEach(function(contribution){
                car.series.initializeContribution(contribution);
            });
        }
    },

    initialize: function() {
        $('.editButton').click(car.series.eventHandlers.editButtonClick);

        car.series.initializeContributions();

        $('.addContributionButton').click(car.series.eventHandlers.addContributionButtonClick);

        $('.saveButton').click(car.series.eventHandlers.saveButtonClick);

        $('.onEdit').hide();
    }
};

$(document).ready(function(){
    car.seriesEditorData = car.seriesEditorData ? car.seriesEditorData : {};
    car.series.initialize();
});

