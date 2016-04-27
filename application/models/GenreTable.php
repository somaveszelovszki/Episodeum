<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-23.
 */

namespace Model;

class GenreTable extends TableModel {

    const TABLE_NAME = 'genre';

    protected function _rowToModel($row){
        return new Genre([
            'id'    =>  (int) $row->id,
            'name'  =>  $row->name
        ]);
    }

    /**
     * @param Genre $genre
     * @return array
     */
    protected function _modelToRow($genre)
    {
        return [
            'id' => $genre->getId(),
            'name' => $genre->getName(),
        ];
    }
}