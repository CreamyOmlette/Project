import React, {useState, FunctionComponent, useEffect} from "react";

interface Post{
    userId: number,
    title: string,
    completed: boolean
}
async function GetResources(url = ''){
    const temp = await fetch(url);
    const json = await temp.json();
    return json;
}

async function PostResources(url: string, post: Post){
    const temp = await fetch(url, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(post)
    });
    return await temp.json();
}

const SecondPage : FunctionComponent<{obj? : any}> = (obj) => {
    const [response, SetResponse] = useState("");
    useEffect(() => {
        PostResources("https://jsonplaceholder.typicode.com/todos", {
            userId: 5,
            title: "Lorem",
            completed: false
        })
        .then(response => JSON.stringify(response))
        .then(response => SetResponse(() => response));
    },[]);
    return (
        <h2>{response}</h2>
    );
}

export default SecondPage;