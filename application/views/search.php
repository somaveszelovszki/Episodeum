
<html>
<head>
    <?php include('elements/html_scripts_and_links.php') ?>
    <script src="<?= base_url() ?>public/js/search.js" type="text/javascript"></script>
</head>
<body>
    <div class="wrapper">
        <?php include('elements/header.php'); ?>
        <div class="content">
            <section class="data-section">
                <div class="data-container">
                    <form id="searchForm" method="post" action="<?= createURIText('person/search') ?>">
                        <table class="data-table">
                            <tr class="title-row">
                                <td colspan="3">Search for person or series</td>
                            </tr>
                            <tr class="data-row">
                                <td><input type="text" name="searchText" /></td>
                                <td>
                                    <label for="personRadioButton">Person</label>
                                    <input class="searchSubjectSelector" id="personRadioButton" type="radio" name="subject" value="person" checked />
                                    <label for="seriesRadioButton">Series</label>
                                    <input class="searchSubjectSelector" id="seriesRadioButton" type="radio" name="subject" value="series" />
                                </td>
                            </tr>
                            <tr>
                                <td><input type="submit" value="Search" name="search" /></td>
                            </tr>
                        </table>
                    </form>
                </div>
            </section>
        </div>
        <?php include('elements/footer.html'); ?>
    </div>
</body>
</html>