<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-23.
 */

class GenreTable extends TableModel {

    protected function _rowToModel($row){
        return new GenreTable([
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