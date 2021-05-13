import React, {Component} from "react";

interface Props{
    onAdd: (text: string) => void
}
// const PostAddForm: React.FC<Props> = ({onAdd}) => {
//     return (
//         <form className="d-flex">
//             <input 
//                 type="text"
//                 placeholder="What do you want to post?"
//                 className="form-post"    
//             />
//             <button type="submit" onClick={() => onAdd("Hello")}>Add</button>
//         </form>
//     );
// };

export default class PostAddForm extends Component<Props, {text: string}>{
    props: Props;
    constructor(props: Props){
        super(props);
        this.props = props;
        this.state = {
            text: ""
        };
        this.onValueChange = this.onValueChange.bind(this);
        this.onSubmit = this.onSubmit.bind(this);
    };
    onValueChange(e: React.FormEvent<HTMLInputElement>){
        e.preventDefault();
        this.setState({
            text: e.currentTarget.value
        });
    }
    onSubmit(e: React.FormEvent<HTMLFormElement>){
        e.preventDefault();
        this.props.onAdd(this.state.text);
        this.setState({
            text: ""
        });
    }
    render(){
        return (
            <form className="d-flex" onSubmit={this.onSubmit}>
                <input 
                type="text"
                placeholder="What do you want to post?"
                className="form-post"  
                onChange={this.onValueChange}  
                value={this.state.text}
                />
                <button type="submit">Add</button>
            </form>
        );
    }

};