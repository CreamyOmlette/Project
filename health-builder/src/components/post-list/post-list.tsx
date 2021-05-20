import React from "react";

import PostListItem from "../post-list-item";

interface PostItem {
    data: string;
    important: boolean;
    id: number;
}
const PostList = ({posts, onDelete, onToggleImportant} : {posts: Array<PostItem>, onDelete: (id:number) => void, onToggleImportant: (id: number) => void}) => {
    const elements = posts.map((item: PostItem) => {
        return (
            <li key={item.id} className="list-group-item">
                <PostListItem {...item} onDelete={() => onDelete(item.id)} onToggleImportant={() => onToggleImportant(item.id)}/>
            </li>
        );
    });
    return (
        <ul>
            {elements}
        </ul>
    )
};

export default PostList;
