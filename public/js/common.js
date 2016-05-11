
/**
 * Creates URI text from text
 * URI pattern: base url + 'index.php?/controller/method
 * @param {string} text
 * @returns {string}
 */
function createURIText(text) {
    // removes base url and 'index.php?' - with or without question mark
    return car.BASE_URL + 'index.php?/' + text.replace(/index\.php(\?)?/, '').replace(car.BASE_URL, '');
}

Array.prototype.max = function(key){
    // null by default
    key = typeof key != 'undefined' ? key : null;

    if (this.length == 0) {
        return null;
    }

    if (!key) {

        return Math.max.apply(null, this);
    } else {
        var max = null;
        var set = false;
        this.forEach(function(element){
            if (element.hasOwnProperty(key)) {
                if (!set) {
                    max = element[key];
                    set = true;
                } else if(max < element[key]) {
                    max = element[key];
                }
            }
        });

        return max;
    }
};

Array.prototype.getElement = function(key, value) {
    var elementToReturn = null;

    elementToReturn = this.find(function(element){
        return element.hasOwnProperty(key) ? element[key] === value : false;
    });

    return elementToReturn;
};

Array.prototype.getElementById = function(id) {
    return this.getElement('id', id);
};

function getDateFromDayOfWeek(dayOfWeek, time){
    var date = new Date();
    var daysToAdd = (dayOfWeek - date.getDay()) >= 0 ? (dayOfWeek - date.getDay()) : (dayOfWeek - date.getDay() + 7);

    // time is a string like '12:35'
    date.setDate(date.getDate() + daysToAdd);
    date.setHours(parseInt(time.substr(0, 2)));
    date.setMinutes(parseInt(time.substr(3, 2)));

    return date;
}

function getDateStringFromDate(date) {
    return date ? date.getFullYear() + '-' + (date.getMonth() + 1) + '-' + date.getDate() + ' ' +
            date.getHours() + ':' + date.getMinutes() + ':' + date.getSeconds() : null;

}