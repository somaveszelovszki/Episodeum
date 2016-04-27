
/**
 * Creates URI text from text
 * URI pattern: base url + 'index.php?/controller/method
 * @param {string} text
 * @returns {string}
 */
function createURIText(text) {
    // removes base url and 'index.php?' - with or without question mark
    return car.baseUrl + 'index.php?/' + text.replace(/index\.php(\?)?/, '').replace(car.baseUrl, '');
}