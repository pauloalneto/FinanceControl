import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-header-custom',
  templateUrl: './header-custom.component.html',
  styleUrls: ['./header-custom.component.scss']
})
export class HeaderCustomComponent implements OnInit {

  @Output() open = new EventEmitter<any>();

  constructor() { }

  ngOnInit(): void {
  }

  onOpenSideNav() {
    this.open.emit(null);
  }

}
