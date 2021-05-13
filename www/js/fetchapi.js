
async function GetResources(){
    const temp = await fetch('https://jsonplaceholder.typicode.com/posts');
    const json = await temp.json();
    return json;
}

// document.addEventListener("DOMContentLoaded" , async () => {
//     const data = await GetResources();
//     console.log(data);
// });


const temp = async () => {
    const data = await GetResources();
    console.log(data);
}

const temp1 = () => fetch('https://jsonplaceholder.typicode.com/posts/1')
.then(response => response.json())
.then(json => console.log(json));

const response = axios.get("https://jsonplaceholder.typicode.com/posts/1")
        .then(data => console.log(typeof(data.data)));