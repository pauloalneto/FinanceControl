import { Component, ElementRef, Input, OnInit, QueryList, ViewChildren } from '@angular/core';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  @Input() menu: any;

  showFiller: boolean = false;
  isOpen: boolean = false;

  @ViewChildren('htmlMenu') htmlMenu = new QueryList<ElementRef>();


  constructor() { }


  ngOnInit(): void {
  }

  toggleMenu(id: any) {
    this.htmlMenu.forEach(item => {
      if (item.nativeElement.id == 'menu_' + id) {
        if (item.nativeElement.classList.contains('navbar-collapse-items'))
          item.nativeElement.classList.remove('navbar-collapse-items');
        else
          item.nativeElement.classList.add('navbar-collapse-items');
      }
    })
  }

}
