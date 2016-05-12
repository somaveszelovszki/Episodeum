<?php
/**
 * This file contains common php functions
 */

/**
 * explodes full names (separated by spaces) to an array containing single names
 * e.g. 'George Example Washington' will become array('George', 'Example', 'Washington')
 * @param string $name
 * @return string[]
 */
function explodeFullName($name) {
    // removes multiple spaces then explodes text by spaces -> no empty values in result array
    return explode(' ', preg_replace('/\s+/i', ' ', $name));
}
/**
 * Creates URI text from text
 * URI pattern: base url + 'index.php?/controller/method
 * @param string $text
 * @returns string
 */
function createURIText($text) {
    // removes base url and 'index.php?/' - with or without question mark
    return base_url() . 'index.php?/' . str_replace(base_url(), '', preg_replace('/index\\.php(\\?)?\\//', '', $text));
}

function sortArrayOfArraysByKey($array, $sortKey, $sort_order = SORT_ASC) {
    $values = [];
    foreach ($array as $key => $value)
    {
        $values[$key] = $value[$sortKey];
    }
    array_multisort($values, $sort_order, $array);

    return $array;
}

/**
 * Converts string to fit in MySQL queries as column name -> replaces capital letters with an underscore and lowercase letter
 * e.g. 'relationshipStateId' will become 'relationship_state_id'
 *
 * @param string $columnName
 * @return string
 */
function strToMySQL($columnName) {
    return strtolower(preg_replace('/([A-Z])/', '_$1', $columnName));
}
/**
 * Converts MySQL column name to Javascript object key string  -> replaces an underscore and lowercase letter with capital letter
 * e.g. 'relationship_state_id' will become 'relationshipStateId'
 * @param string $columnName
 * @return string
 */
function strToJavasript($columnName) {
    return preg_replace_callback('/_([a-zA-Z])/', function ($matches) {
        return strtoupper($matches[1]);		// $matches[1] contains letter after '_'
    }, $columnName);
}
/**
 * Toggles object keys between strings that fit to MySQL queries as column names and Javascript object keys
 * -> replaces capital letters with an underscore and lowercase letter
 * e.g. $options['relationshipStateId'] will become $options['relationship_state_id']
 * @param array $object
 * @param string $convertTo
 * @param bool|true $allLevelSearch determines if search should continue to all levels (member objects in object)
 * @return array
 */
function toggleObjectKeyNames($object, $convertTo, $allLevelSearch = true) {
    if (!is_array($object)) {
        return $object;
    }
    foreach ($object as $key => $value) {
        if (is_array($value) && $allLevelSearch) {		// going through all levels if enabled
            $object[$key] = toggleObjectKeyNames($value, $convertTo, true);
        }
        // storing variable
        $temp = $object[$key];
        // deleting from object
        unset($object[$key]);
        //creates new element in object with converted key name
        switch (strtolower($convertTo)) {
            case 'mysql':
                $object[strToMySQL($key)] = $temp;
                break;
            case 'javascript':
                $object[strToJavasript($key)] = $temp;
                break;
        }
    }
    return $object;
}
/**
 * Converts object keys to fit into MySQL query
 * @param Object $object
 * @param bool|true $allLevelSearch determines if search should continue to all levels (member objects in object)
 * @return array
 */
function objectKeysToMySQL($object, $allLevelSearch = true) {
    return toggleObjectKeyNames($object, 'mysql', $allLevelSearch);
}
/**
 * Converts object keys to Javascript style
 * @param array $object
 * @param bool|true $allLevelSearch determines if search should continue to all levels (member objects in object)
 * @return array
 */
function objectKeysToJavascript($object, $allLevelSearch = true) {
    return toggleObjectKeyNames($object, 'javascript', $allLevelSearch);
}
/**
 * Determines whether person1, person2 or both people (couple) logged in
 * @param array $personIds
 * @return null|string
 */
function determineAccessId($personIds) {
    if (is_array($personIds)) {
        switch (count($personIds)) {
            case 0:		// something failed
                return null;
            case 1:		// only one person logged in
                return isset($personIds['1']) ? $personIds['1'] : $personIds['2'];
            case 2:		// both people together logged in (as couple)
                return 'couple';
        }
    }
    return null;
}

/**
 * @param DateTime $dateTime
 * @return string|null date string - nice and readable for users - e.g. 'October 20 2015'
 */
function getDateStringFromDateTime($dateTime) {
    return $dateTime ? $dateTime->format("F j Y") : null;
}

/**
 * Converts DateTime objects to a string that can be inserted into the DB as a date
 * @param $dateTime DateTime
 * @return string date formatted so that it can be inserted into the DB as a date (e.g. '2016-04-23')
 */
function getSQLDateFromDateTime($dateTime) {
    return $dateTime ? $dateTime->format("Y-m-d") : null;
}

/**
 * Converts SQL date objects to DateTime objects
 * @param $SQLDate
 * @return DateTime
 */
function getDateTimeFromSQLDate($SQLDate) {
    return $SQLDate ? new DateTime($SQLDate) : null;
}

/**
 * Converts DateTime objects to a string that can be inserted into the DB as a datetime
 * @param $dateTime DateTime
 * @return string date formatted so that it can be inserted into the DB as a datetime (e.g. '2016-04-23 16:03:24')
 */
function getSQLDateTimeFromDateTime($dateTime) {
    return $dateTime ? $dateTime->format("Y-m-d H:i:s") : null;
}

/**
 * Converts SQL datetime objects to DateTime objects
 * @param $SQLDateTime
 * @return DateTime
 */
function getDateTimeFromSQLDateTime($SQLDateTime) {
    return $SQLDateTime ? getDateTimeFromSQLDate($SQLDateTime) : null;
}

function getImdbUrl($imdbId) {
    $idPattern = '{id}';
    $imdbUrlTemplate = 'http://www.imdb.com/title/' . $idPattern . '/';

    return $imdbId ? str_replace($idPattern, $imdbId, $imdbUrlTemplate) : null;
}

function numberStringsToNumbers ($object) {
    if (!is_array($object)) {
        return $object;
    }
    foreach ($object as $key => $value) {
        if (is_array($value)) {		// going through all levels
            $object[$key] = numberStringsToNumbers($value);
        } else {
            /** Regexp matches numbers (e.g. '1', '12.4', '.7')
             * DOES NOT MATCH: '12.', '', ' '
             * Regexp explanation:
             * [\\d]*	->	matches 0 or more digits
             * [\\.]*	->	matches 0 or more dots
             * [\\d]+	->	matches 1 or more digits
             */
            $numberRegexp = '/^[\\d]*[\\.]*[\\d]+$/';
            $object[$key] = preg_match($numberRegexp, $value) ? (int) $value : $value;
        }
    }
    return $object;
}

function getNumberInSeparatedFormat($number){
    return number_format($number, 2, '.', ' ');
}

function getNumberInReadableFormat($number) {
    if (gettype($number) == 'integer') {
        if ($number < 1000) {
            return $number;
        }

        if ($number < 1000000) {
            return getNumberInSeparatedFormat($number/1000) . ' thousand';
        }

        if ($number < 1000000000) {
            return getNumberInSeparatedFormat($number/1000000) . ' million';
        }

        if ($number < 1000000000000) {
            return getNumberInSeparatedFormat($number/1000000000) . ' billion';
        }

        if ($number < 1000000000000000) {
            return getNumberInSeparatedFormat($number/1000000000000) . ' trillion';
        }
    }
    return null;
}

function isImdbIdValid($imdbId) {
    return !empty($imdbId) && gettype($imdbId) === 'string' && strlen($imdbId) == 9 && substr($imdbId, 0, 2) === "tt";
}
