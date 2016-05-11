<?php
    $errorMessage = isset($errorMessage) ? $errorMessage : '';
?>
<html>
<head>
    <?php include('elements/html_scripts_and_links.php') ?>
</head>
<body>
    <div class="wrapper">
        <?php include('elements/header.php'); ?>
        <div class="content">
            <p><?= $errorMessage ?></p>
        </div>
        <?php include('elements/footer.html'); ?>
    </div>
</body>
</html>