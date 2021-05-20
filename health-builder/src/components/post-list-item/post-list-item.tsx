import React, {Component} from "react";
interface PostItem {
    data: string,
    important?: boolean,
    id: number,
    onDelete: () => void
    onToggleImportant: () => void
}
class PostListItem extends Component {
    props: PostItem;
    onDelete: () => void;
    onToggleImportant: () => void;
    constructor(props: PostItem){
        super(props);
        this.props = props;
        this.onDelete = this.props.onDelete.bind(this);
        this.onToggleImportant = this.props.onToggleImportant.bind(this);
    }

    render() {
        const {data} : {data: string} = 
        this.props;
        let className = "";
        if(this.props.important){
            className+= "important";
        }
        return (
            <div className="d-flex justify-center">
            <span className={className}>
                {data}
            </span>
                <div className="btn-group">
                    <button className="fav" onClick={this.onToggleImportant}>fav</button>
                    <button className="delete" onClick={this.onDelete}>delete</button>
                    <button className="like">like</button>
                </div>               
            </div>
    );
    }
}
// const PostListItem = ({data, important = false} : {data: string, important?: boolean}) => {   
//     return (
//             <div className="d-flex justify-center">
//             <span>
//                 {data}
//             </span>
//                 <div className="btn-group">
//                     <button className="fav">fav</button>
//                     <button className="delete">delete</button>
//                     <button className="like">like</button>
//                 </div>               
//             </div>
//     );
// };

export default PostListItem;