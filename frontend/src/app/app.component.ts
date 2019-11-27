import { Component, OnInit } from '@angular/core';
import { Apollo } from 'apollo-angular';
import gql from 'graphql-tag';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  friends: any;
  loading = true;
  id: string;
  selectCharacter: 'human';
  characters: any;
  searchTerm: string;

  constructor(private apollo: Apollo) {
    this.id = '1';
  }

  ngOnInit(): void {
    this.runQuery();
  }

  runQuery() {
    if (!this.selectCharacter) {
      this.selectCharacter = 'human';
    }

    const query = `{ all${this.selectCharacter}s { ${this.selectCharacter}s { id name age appearsIn friends { name appearsIn } } } }`;

    const getRecord =  gql(query);
    this.apollo
      .watchQuery({
        query: getRecord
      })
      .valueChanges.subscribe(result => {
        this.characters = result.data && result.data[`all${this.selectCharacter}s`][`${this.selectCharacter}s`];
        this.loading = result.loading;
      });
  }
}
