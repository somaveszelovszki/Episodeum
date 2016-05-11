<header>
    <div>
        <a class="left main-logo" href="<?= base_url() ?>">
            <img src="<?= base_url() . 'images/logo-50.svg' ?>" alt="Episodeum"/>
        </a>
    </div>
    <div class="tabs-list">
        <div class="tab-element page-selector">
            <a class="page-anchor" href="<?= createURIText('series/list') ?>">
                <span>Series list</span>
            </a>
        </div>
        <div class="tab-element page-selector">
            <a class="page-anchor" href="<?= createURIText('person/list') ?>">
                <span>Person list</span>
            </a>
        </div>
        <div class="tab-element page-selector">
            <a class="page-anchor" href="<?= createURIText('search/index') ?>">
                <span>Search</span>
            </a>
        </div>
    </div>
</header>