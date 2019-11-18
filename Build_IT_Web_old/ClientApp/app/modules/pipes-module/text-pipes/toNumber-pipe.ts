import { PipeTransform, Pipe } from '@angular/core';

@Pipe({ name: 'toNumber' })
export class ToNumberPipe implements PipeTransform {
    transform(value: string): number {
        return parseFloat(value.replace(',','.'));
    }
}