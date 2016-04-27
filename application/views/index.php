<html>
<head>
	<title>Episodeum</title>
    <?php include('elements/html_scripts_and_links.php') ?>
</head>
<body>
    <div class="page-selector">
        <a class="page-anchor" href="<?= createURIText('series/list') ?>">
            <span>Series list</span>
            <img src="" />
        </a>
    </div>
    <div class="tab-element page-selector">
        <a class="page-anchor" href="<?= createURIText('person/list') ?>">
            <span>Person list</span>
            <img src="" />
        </a>
    </div>
    <div class="page-selector">
        <a class="page-anchor" href="<?= createURIText('search/index') ?>">
            <span>Search</span>
            <img src="" />
        </a>
    </div>
</body>
</html>