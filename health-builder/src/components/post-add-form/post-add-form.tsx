import React, {Component, useState} from "react";

interface Props{
    onAdd: (text: string) => void
}

const PostAddForm = (props: Props) => {
    const [text, setText] = useState<string>("");
    const onValueChange = (e: React.FormEvent<HTMLInputElement>) => {
        e.preventDefault();
        setText(e.currentTarget.value);
    };
    const onSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        props.onAdd(text);
        setText("");
    };
    return (
            <form className="d-flex" onSubmit={onSubmit}>
                <input 
                type="text"
                placeholder="What do you want to post?"
                className="form-post"  
                onChange={onValueChange}  
                value={text}
                />
                <button type="submit">Add</button>
            </form>
    );
};

export default PostAddForm;
// export default class PostAddForm extends Component<Props, {text: string}>{
//     props: Props;
//     constructor(props: Props){
//         super(props);
//         this.props = props;
//         this.state = {
//             text: ""
//         };
//         this.onValueChange = this.onValueChange.bind(this);
//         this.onSubmit = this.onSubmit.bind(this);
//     };
//     onValueChange(e: React.FormEvent<HTMLInputElement>){
//         e.preventDefault();
//         this.setState({
//             text: e.currentTarget.value
//         });
//     }
//     onSubmit(e: React.FormEvent<HTMLFormElement>){
//         e.preventDefault();
//         this.props.onAdd(this.state.text);
//         this.setState({
//             text: ""
//         });
//     }
//     render(){
//         return (
//             <form className="d-flex" onSubmit={this.onSubmit}>
//                 <input 
//                 type="text"
//                 placeholder="What do you want to post?"
//                 className="form-post"  
//                 onChange={this.onValueChange}  
//                 value={this.state.text}
//                 />
//                 <button type="submit">Add</button>
//             </form>
//         );
//     }

// };