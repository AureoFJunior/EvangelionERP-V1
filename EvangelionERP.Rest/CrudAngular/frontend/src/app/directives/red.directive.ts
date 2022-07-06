import { Directive, ElementRef } from '@angular/core';

@Directive({
  selector: '[appRed]'
})
export class RedDirective {

  //Utilizado para aprender sobre diretivas (não estrutural)
  constructor(private el: ElementRef) {
    el.nativeElement.style.color = '#e35e6b'

   }

}
