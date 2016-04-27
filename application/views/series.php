
<html>
<head>
    <?php include('elements/html_scripts_and_links.php') ?>
</head>
<body>
    <div class="wrapper">
        <?php include('elements/header.php'); ?>
        <div class="content">
            <section class="data-section">
                <div class="data-container">
                    <table class="data-table" data-id="<?= $series->getId() ?>">

                        <tr class="data-row">
                            <td><b>Title:</b></td>
                            <td><?= $series->getTitle() ?></td>
                        </tr>

                        <tr class="data-row">
                            <td><b>Nationality:</b></td>
                            <td><?= ($c = $series->getCountry()) != null ? $c->getNationality() : _UNKNOWN ?></td>
                        </tr>

                        <tr class="data-row">
                            <td><b>Age limit:</b></td>
                            <td><?= ($c = $series->getAgeLimit()) != null ? $c->getAge() : _UNKNOWN ?></td>
                        </tr>

                        <tr class="data-row">
                            <td><b>Viewers:</b></td>
                            <td><?= ($v = $series->getViewNumber()) != null ? getNumberInReadableFormat($v) : _UNKNOWN ?></td>
                        </tr>

                        <tr class="data-row">
                            <td><b>Show time:</b></td>
                            <td><?= $series->getIsOnProgram() ?
                                    (($s = $series->getShowTimeAsTVShowTime()) != null ? $s : _UNKNOWN) :
                                    'This series is not on program at the moment.'
                                ?></td>
                        </tr>

                        <?php if (($imdbId = $series->getImdbId()) != null) : ?>
                            <tr class="data-row">
                                <td colspan="2"><a href="<?= getImdbUrl($imdbId) ?>">Check series on IMDb</a></td>
                            </tr>
                        <?php endif ?>

                        <tr>
                            <td colspan="2">
                                <?php if (($c = $series->getPersonContributions()) != null) : ?>
                                    <div class="data-section mid-wide">
                                        <div class="data-container">
                                            <table class="data-table">
                                                <?php foreach($series->getPersonContributionsWithPersonData() as $con) : ?>
                                                    <tr>
                                                        <td>
                                                            <a class="page-anchor" href="<?= createURIText('person/data/' . $con['person']->getId()) ?>">
                                                                <b><?= $con['person']->getName() ?></b>
                                                            </a>
                                                        </td>
                                                        <td>
                                                            <?= $con['contribution']->getName() ?>
                                                        </td>
                                                    </tr>
                                                <?php endforeach ?>
                                            </table>
                                        </div>
                                    </div>
                                <?php endif ?>
                            </td>

                        </tr>

                    </table>
                </div>
            </section>
        </div>
        <?php include('elements/footer.html'); ?>
    </div>
</body>
</html>