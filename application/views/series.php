<?php
    $countries = $countries ? $countries : [];
    $ageLimits = $ageLimits ? $ageLimits : [];
    $series = $series ? $series : null;
    $genres = $genres ? $genres : [];
    $contributions = $contributions ? $contributions : null;
    $persons = $persons ? $persons : null;

    $daysOfWeek = [
        '0' =>  'Sunday',
        '1' =>  'Monday',
        '2' =>  'Tuesday',
        '3' =>  'Wednesday',
        '4' =>  'Thursday',
        '5' =>  'Friday',
        '6' =>  'Saturday'
    ];

    // creates array of times for user to choose from
    // e.g. '19:45'
    $times = [];
    for ($h = 0; $h < 24; $h++) {
        for ($m = 0; $m < 60; $m+= 5) {
            $times[] = (($h < 10) ? '0' : '') . $h . ':' . (($m < 10) ? '0' : '') . $m;
        }
    }

    $ageLimitsForJs = [];
    foreach($ageLimits as $ageLimit) {
        $ageLimitsForJs[] = \Model\AgeLimitTable::getInstance()->_modelToRow($ageLimit);
    }

    $personsForJs = [];
    foreach($persons as $person) {
        $personsForJs[] = [
            'id'    =>  $person->getId(),
            'name'  =>  $person->getName()
        ];
    }

    $countriesForJs = [];
    foreach($countries as $country) {
        $countriesForJs[] = \Model\CountryTable::getInstance()->_modelToRow($country);
    }

    $contributionsForJs = [];
    foreach($contributions as $con) {
        $contributionsForJs[] = \Model\ContributionTable::getInstance()->_modelToRow($con);
    }

    $seriesForJs = $series ? \Model\SeriesTable::getInstance()->_modelToRow($series) : null;

    if ($seriesForJs) {
        $seriesForJs['contributions'] = [];
        if (($cons = $series->getPersonContributions()) != null) {
            foreach ($cons as $con) {
                $seriesForJs['contributions'][] = [
                    'id'                =>  $con->getId(),
                    'personId'          =>  $con->getPersonId(),
                    'contributionId'    =>  $con->getContributionId()
                ];
            }
        }
    }
?>

<html>
<head>
    <?php include('elements/html_scripts_and_links.php') ?>
    <script src="<?= base_url() ?>public/js/series.js" type="text/javascript"></script>
</head>
<body>
    <div class="wrapper">
        <?php include('elements/header.php'); ?>
        <div class="content">
            <?php if ($series) : ?>
                <section class="data-section">
                    <div class="data-container">
                        <table class="data-table series-data" data-id="<?= $series->getId() ?>">

                            <tr class="data-row">
                                <td><b>Title:</b></td>
                                <td class="onView"><?= $series->getTitle() ?></td>
                                <td class="onEdit"><input class="title-field" type="text" value="<?= $series->getTitle() ?>"/></td>
                            </tr>

                            <tr class="data-row">
                                <td><b>Country:</b></td>
                                <td class="onView"><?= $series->getCountry()->getName() ?></td>
                                <td class="onEdit">
                                    <select class="country-field">
                                        <?php foreach($countries as $country) : ?>
                                            <option value="<?= $country->getId() ?>"
                                                <?= $country->getId() == $series->getCountryId() ? 'selected="selected"' : '' ?>
                                                ><?= $country->getName() ?></option>
                                        <?php endforeach ?>
                                    </select>
                                </td>
                            </tr>

                            <tr class="data-row">
                                <td><b>Genre:</b></td>
                                <td class="onView"><?= $series->getGenre()->getName() ?></td>
                                <td class="onEdit">
                                    <select class="genre-field">
                                        <?php foreach($genres as $genre) : ?>
                                            <option value="<?= $genre->getId() ?>"
                                                <?= $genre->getId() == $series->getGenreId() ? 'selected="selected"' : '' ?>
                                                ><?= $genre->getName() ?></option>
                                        <?php endforeach ?>
                                    </select>
                                </td>
                            </tr>

                            <tr class="data-row">
                                <td><b>Age limit:</b></td>
                                <td class="onView"><?= ($c = $series->getAgeLimit()) != null ? $c->getAge() : _UNKNOWN ?></td>
                                <td class="onEdit">
                                    <select class="age-limit-field">
                                        <?php foreach($ageLimits as $ageLimit) : ?>
                                            <option value="<?= $ageLimit->getId() ?>"
                                                <?= $ageLimit->getId() == $series->getAgeLimitId() ? 'selected="selected"' : '' ?>
                                                ><?= $ageLimit->getAge() ?></option>
                                        <?php endforeach ?>
                                    </select>
                                </td>
                            </tr>

                            <tr class="data-row">
                                <td><b>Viewers:</b></td>
                                <td class="onView"><?= ($v = $series->getViewNumber()) != null ? getNumberInReadableFormat($v) : _UNKNOWN ?></td>
                                <td class="onEdit"><input class="view-number-field" type="number" value="<?= $v ? $v : '' ?>"/></td>
                            </tr>

                            <tr class="data-row onView">
                                <td><b>Show time:</b></td>
                                <td><?= ($isOnProgram = $series->getIsOnProgram()) != null ?
                                        (($s = $series->getShowTimeAsTVShowTime()) != null ? $s : _UNKNOWN) :
                                        'This series is not on program at the moment.'
                                    ?></td>
                            </tr>

                            <tr class="onEdit">
                                <td><b>Is series on program?</b></td>
                                <td>
                                    <label for="programYes">Yes</label>
                                    <input class="is-on-program-selector-field" id="programYes" type="radio"
                                           name="subject" value="1" <?= $isOnProgram ? 'checked' : '' ?> />
                                    <label for="programNo">No</label>
                                    <input class="is-on-program-selector-field" id="programNo" type="radio"
                                           name="subject" value="0"  <?= $isOnProgram ? '' : 'checked' ?>/>
                                </td>
                                <td class="onEdit">
                                    <select class="show-day-field">
                                        <?php foreach($daysOfWeek as $dayId => $day) : ?>
                                            <option value="<?= $dayId ?>"
                                                <?= $dayId == $series->getShowTimeDayId() ? 'selected="selected"' : '' ?>
                                                ><?= $day ?></option>
                                        <?php endforeach ?>
                                    </select>
                                </td>
                                <td class="onEdit">
                                    <select class="show-time-field">
                                        <?php foreach($times as $time) : ?>
                                            <option value="<?= $time ?>"
                                                <?= $time == $series->getShowTimeInTimeFormat() ? 'selected="selected"' : '' ?>
                                                ><?= $time ?></option>
                                        <?php endforeach ?>
                                    </select>
                                </td>
                            </tr>

                            <?php if (($imdbId = $series->getImdbId()) != null) : ?>
                                <tr class="data-row onView">
                                    <td colspan="2"><a href="<?= getImdbUrl($imdbId) ?>">IMDb</a></td>
                                </tr>
                            <?php endif ?>

                            <tr class="onEdit">
                                <td><b>IMDb id:</b></td>
                                <td class="onEdit"><input class="imdb-id-field" type="text" value="<?= $imdbId ? $imdbId : '' ?>"/></td>
                            </tr>

                            <tr class="contribution-list">
                                <td colspan="4">
                                    <div class="data-section mid-wide">
                                        <div class="data-container">
                                            <table class="data-table">

                                            </table>
                                            <button class="addContributionButton onEdit">Add</button>
                                        </div>
                                    </div>
                                </td>
                            </tr>

                        </table>
                        <button class="editButton">Edit</button>
                        <button class="saveButton onEdit">Save</button>
                    </div>
                </section>
            <?php endif ?>
        </div>
        <?php include('elements/footer.html'); ?>
    </div>
</body>
    <script>
        car.seriesEditorData = <?= json_encode([
    	'ageLimits' => $ageLimitsForJs,
    	'countries' => $countriesForJs,
    	'series' => $seriesForJs,
    	'contributions' =>  $contributionsForJs,
    	'persons'   =>  $personsForJs
    ]) ?>;
    </script>
</html>