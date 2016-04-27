
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
                    <table class="data-table" data-id="<?= $person->getId() ?>">

                        <tr class="data-row">
                            <td><b>First name:</b></td>
                            <td><?= $person->getFirstName() ?></td>
                        </tr>

                        <tr class="data-row">
                            <td><b>Surname:</b></td>
                            <td><?= $person->getSurname() ?></td>
                        </tr>

                        <tr class="data-row">
                            <td><b>Gender:</b></td>
                            <td><?= $person->getGender()->getName() ?></td>
                        </tr>

                        <tr class="data-row">
                            <td><b>Nationality:</b></td>
                            <td><?= ($c = $person->getCountry()) != null ? $c->getNationality() : _UNKNOWN ?></td>
                        </tr>

                        <tr class="data-row">
                            <td><b>Birthday:</b></td>
                            <td><?= ($b = $person->getBirthDate()) != null ? getDateStringFromDateTime($b) : _UNKNOWN ?></td>
                        </tr>

                        <tr>
                            <td colspan="2">
                                <?php if (($c = $person->getSeriesContributions()) != null) : ?>
                                    <div class="data-section mid-wide">
                                        <div class="data-container">
                                            <table class="data-table">
                                                <?php foreach($person->getSeriesContributionsWithSeriesData() as $con) : ?>
                                                    <tr>
                                                        <td>
                                                            <a class="page-anchor" href="<?= createURIText('series/data/' . $con['series']->getId()) ?>">
                                                                <b><?= $con['series']->getTitle() ?></b>
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
                                <?php if (!$c) : ?>
                                    <td><?= $person->getSeriesContributionsAsString() ?></td>
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