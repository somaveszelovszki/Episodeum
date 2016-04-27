
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
            <?php if (isset($seriesList) && !empty($seriesList)) : ?>
                <div class="list-container">
                    <ul class="list">
                        <?php foreach($seriesList as $series) : ?>
                            <li class="list-element">
                                <div class="data-container">
                                    <a class="page-anchor" href="<?= createURIText('series/data/' . $series->getId()) ?>">
                                        <table class="data-table" data-id="<?= $series->getId() ?>">
                                            <tr class="title-row">
                                                <td colspan="3">
                                                    <?= $series->getTitle() ?>
                                                </td>
                                            </tr>
                                            <tr class="data-row">
                                                <td>
                                                    <?php
                                                    $text = ($c = $series->getCountry()) != null ? $c->getNationality() . ' ' : '';
                                                    $text .= $series->getGenre()->getName() . ' series';

                                                    echo $text;
                                                    ?>
                                                </td>
                                            </tr>
                                            <tr class="data-row">
                                                <td><?= ($v = $series->getViewNumber()) != null ? getNumberInReadableFormat($v) . ' viewers' : '' ?></td>
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