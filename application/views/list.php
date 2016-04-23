

<html>
<head>
    <?php include('elements/html_scripts_and_links.php'); ?>
</head>
<body>
    <?php include('elements/header.html'); ?>
    <div class="content">
        <?php foreach($seriesList as $series) : ?>
            <div>
                <?= $series->getAge() ?>
            </div>
        <?php endforeach ?>
    </div>
    <?php include('elements/footer.html'); ?>
</body>
</html>