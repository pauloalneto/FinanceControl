import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  menu: any = [];

  constructor() { }

  ngOnInit(): void {

    this.menu = [
      {
        icon: 'bi-bar-chart', route: '/', title: 'Dashboard', children:
          [
            { icon: 'bi-clipboard-chart', route: '/', title: 'Dashboard' },
            { icon: 'bi-clipboard-chart', route: '/', title: 'Dashboard' },
            { icon: 'bi-clipboard-chart', route: '/', title: 'Dashboard' },
          ]
      },
      { icon: 'bi-clipboard-data', route: '/', title: 'Report' },
      { icon: 'bi-credit-card', route: '/', title: 'Cards' },
      {
        icon: 'bi-currency-dollar', route: '/', title: 'Invoice', children:
          [
            { icon: 'bi-clipboard-chart', route: '/', title: 'Dashboard' },
            { icon: 'bi-clipboard-chart', route: '/', title: 'Dashboard' },
            { icon: 'bi-clipboard-chart', route: '/', title: 'Dashboard' },
          ] },
    ]

  }

  openSideNav(event: any) {
    console.log('testeclick ', event)
  }


}
