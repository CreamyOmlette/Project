import React from "react";
interface Props{
    favourites: number,
    allPosts: number
}
const AppHeader: React.FC<Props> = ({favourites, allPosts}) => {
    return (
        <div>
            <h1>Alexei Lipceanu</h1>
            <h2>{allPosts} posts, from which {favourites} are favourites</h2>
        </div>
    );
};

export default AppHeader;