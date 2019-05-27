import { Component, OnInit, Input, ElementRef, ViewChild } from '@angular/core';
import { Tag } from '../../../models/interfaces/tag';
import { TagService } from '../../../services/tag.service';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { FormGroup, FormControl, FormArray, AbstractControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { MatAutocomplete, MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { startWith, map } from 'rxjs/operators';
import { MatChipInputEvent } from '@angular/material/chips';
import { TagImpl } from '../../../models/tagImpl';

@Component({
    selector: 'tag-form',
    templateUrl: './tag-form.component.html',
    styleUrls: ['./tag-form.component.scss']
})

export class TagFormComponent implements OnInit {
    @Input('scriptForm') scriptForm: FormGroup;

    tags: Tag[];

    visible = true;
    selectable = true;
    removable = true;
    addOnBlur = true;
    separatorKeysCodes: number[] = [ENTER, COMMA];
    tagCtrl = new FormControl();
    filteredTags: Observable<Tag[]>;

    @ViewChild('tagInput') tagInput: ElementRef<HTMLInputElement>;
    @ViewChild('auto') matAutocomplete: MatAutocomplete;

    get scriptId(): AbstractControl {
        return this.scriptForm.get('id');
    }

    get scriptTags(): FormArray {
        return this.scriptForm.get('tags') as FormArray;
    }

    constructor(private tagService: TagService) {
    }

    ngOnInit() {
        this.filteredTags = this.tagCtrl.valueChanges.pipe(
            startWith(null),
            map((tagName: string | null) => tagName ? this._filter(tagName) : this.tags));

        this.getTags();
    }

    private getTags() {
        this.tagService.getTags().subscribe((tags: Tag[]) => {
            this.tags = tags;
            this.tagCtrl.setValue(null);
        }, error => console.error(error));
    }

    add(event: MatChipInputEvent): void {
        if (!this.matAutocomplete.isOpen) {
            const input = event.input;
            const value = event.value;

            if ((value || '').trim() && !this.scriptTags.controls.some(c => c.value.name == value.trim())) {
                
                this.scriptTags.push(new FormGroup({
                    id: new FormControl(0),
                    name: new FormControl(value.trim())
                }));
            }

            if (input) {
                input.value = '';
            }
            
            if (this.scriptTags.controls.length > 5)
                this.tagCtrl.setValue('###Not supposed to be on the list###');
            else
                this.tagCtrl.setValue(null);
        }
    }

    remove(tagForm: FormGroup): void {
        const index = this.scriptTags.controls.indexOf(tagForm);

        if (index >= 0) {
            this.scriptTags.removeAt(index);
        }
    }

    selected(event: MatAutocompleteSelectedEvent): void {
        let tag = this.tags.find(t => t.name == event.option.viewValue);
        if (tag == null) {
            this.tagInput.nativeElement.value = '';
            this.tagCtrl.setValue(null);
            return;
        }

        this.scriptTags.push(new FormGroup({
            id: new FormControl(tag.id),
            name: new FormControl(tag.name)
        }));
        this.tagInput.nativeElement.value = '';
        this.tagCtrl.setValue(null);
    }

    private _filter(value: string): Tag[] {
        const filterValue = value.toLowerCase();

        return this.tags.filter(t => t.name.toLowerCase().indexOf(filterValue) === 0 );
    }
}