import React, {Component} from 'react';
import './App.scss';
import AppHeader from "../app-header";
import SearchPanel from "../search-panel";
import PostStatusFilter from "../post-status-filter";
import PostList from "../post-list";
import PostAddForm from "../post-add-form";

// const App = () => {
//   const posts = [
//     {data: "Learning React", important: false, id: "qwwqw"},
//     {data: "Learning React", important: false, id: "qwqqq"}
//   ];
//   return(
//     <div className="App">
//       <AppHeader/>
//       <div className="d-flex search-panel">
//         <SearchPanel/>
//         <PostStatusFilter/>
//       </div>
//       <PostList posts = {posts} onDelete={(id:string) => console.log(id)}/>
//       <PostAddForm/>
//     </div>
//   );
// };

export default class App extends Component<{}, {posts: Array<{data: string, important: boolean, id: number}>}>{
  max: number;
  constructor(){
    super({});
    this.state = {
       posts : [
        {data: "Learning React", important: false, id: 1},
        {data: "Learning React", important: false, id: 2}
      ]
    };
    this.deleteItem = this.deleteItem.bind(this);
    this.addItem = this.addItem.bind(this);
    this.onToggleImportant = this.onToggleImportant.bind(this);
    this.max = 3;
  }
  deleteItem(id: number){
    this.setState(({posts}) => {
      const index = posts.findIndex(elem => elem.id === id);
      const before = posts.slice(0, index);
      const after = posts.slice(index+1);
      const arr = [...before, ...after]; 
      return { posts : arr};
    });
  }
  addItem(text: string){
    const newItem = {
      data: text,
      important: false,
      id: this.max++
    };
    this.setState(({posts}) => {
      const arr = [...posts, newItem];
      return {posts: arr};
    });
  }
  onToggleImportant(id: number){
    this.setState(({posts}) => {
        const index = posts.findIndex(item => item.id === id);
        const changedItem = posts[index];
        changedItem.important = !changedItem.important;
        const arr = [...posts.slice(0,index), changedItem, ...posts.slice(index+1)];
        return {posts: arr};
    });
  }
  render(){
    const favourites = this.state.posts.filter(item => item.important).length;
    const allPosts = this.state.posts.length;
      return(
        <div className="App">
          <AppHeader favourites={favourites} allPosts={allPosts}/>
            <div className="d-flex search-panel">
              <SearchPanel/>
              <PostStatusFilter/>
             </div>
          <PostList posts = {this.state.posts} onDelete={this.deleteItem} onToggleImportant={this.onToggleImportant}/>
          <PostAddForm onAdd={this.addItem}/>
        </div>
      );
  }
};
