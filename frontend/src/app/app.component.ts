import { Component, OnInit } from '@angular/core';
import { Apollo } from 'apollo-angular';
import gql from 'graphql-tag';
import { ThrowStmt } from '@angular/compiler';

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
  editId: string;
  
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

    this.editId = null;

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

  save(item){

    let mutationQuery = null;
    let data = null;

    if (this.selectCharacter == 'human') {
      mutationQuery = gql('mutation ($human:HumanInput!) { editHuman(human: $human) { id, name } }');
      data = {
        human: {
          id: item.id,
          name: item.name
        }
      };
    } else {
      mutationQuery = gql('mutation ($droid:DroidInput!) { editDroid(droid: $droid) { id, name } }');
      data = {
        droid: {
          id: item.id,
          name: item.name
        }
      };
    }

    this.apollo.mutate({
      mutation: mutationQuery,
      variables: data
    }).subscribe(({ data }) => {
      debugger;
      console.log('got data', data);
    },(error) => {
      debugger;
      console.log('there was an error sending the query', error);
    });
    console.log(item);
  }
}
