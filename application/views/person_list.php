
<html>
<head>
    <?php include('elements/html_scripts_and_links.php'); ?>
</head>
<body>
    <div class="wrapper">
        <?php include('elements/header.php'); ?>
        <div class="content">
            <?php if (isset($message)) : ?>
                <section class="message-section">
                    <span><?= $message ?></span>
                </section>
            <?php endif ?>
            <?php if (isset($personList) && !empty($personList)) : ?>
                <div class="list-container">
                    <ul class="list">
                        <?php foreach($personList as $person) : ?>
                            <li class="list-element">
                                <div class="data-container">
                                    <a class="page-anchor" href="<?= createURIText('person/data/' . $person->getId()) ?>">
                                        <table class="data-table" data-id="<?= $person->getId() ?>">
                                            <tr class="title-row">
                                                <td colspan="3">
                                                    <?= $person->getName() ?>
                                                </td>
                                            </tr>
                                            <tr class="data-row">
                                                <td>
                                                    <?= $person->getSeriesContributionsAsString() ?>
                                                </td>
                                            </tr>
                                        </table>
                                    </a>
                                </div>
                            </li>
                        <?php endforeach ?>
                    </ul>
                </div>
            <?php endif ?>
        </div>
        <?php include('elements/footer.html'); ?>
    </div>
</body>
</html>