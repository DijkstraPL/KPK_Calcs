import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { Parameter } from '../../../../models/interfaces/parameter';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { ValueOption } from '../../../../models/interfaces/valueOption';

@Component({
    selector: 'parameter-autocomplete',
    templateUrl: './parameter-autocomplete.component.html',
    styleUrls: ['./parameter-autocomplete.component.scss']
})

export class ParameterAutocompleteComponent implements OnInit {

    filteredValueOptions: Observable<ValueOption[]>;
    valueOptionsForm = new FormControl();

    @Input() parameter: Parameter = null;
    @Output() valueChanged = new EventEmitter<Parameter>();

    constructor() {
    }

    ngOnInit(): void {
        this.filteredValueOptions = this.valueOptionsForm.valueChanges.pipe(
            startWith(''),
            map(value => this._filter(value))
        );
    }

    private _filter(value: string): ValueOption[] {
        const filterValue = value.toLowerCase();

        return this.parameter.valueOptions.filter(option =>
            option.value.toLowerCase().indexOf(filterValue) === 0);
    }

    changeValue(): void {
        this.valueChanged.emit(this.parameter);
    }
}