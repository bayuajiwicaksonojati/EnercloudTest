import React, { useEffect, useState } from "react"
import axios from 'axios';
import parse from 'html-react-parser';

export default function StringComparer(){
    const [isLoading, setisLoading] = useState(false)
    const [isError, setisError] = useState(false)
    const [errorMessage, seterrorMessage] = useState(null)

    const [fulltextInput, setFulltextInput] = useState('')
    const [testtextInput, setTesttextInput] = useState('')

    const [occurenceIndexes, setoccurenceIndexes] = useState([])
    const [fulltextJustSubmitted, setfulltextJustSubmitted] = useState('')
    const [testtextJustSubmitted, settesttextJustSubmitted] = useState('')
    const [htmlElementOfFullText, sethtmlElementOfFullText] = useState('');

    const compare = async () => {
        setisLoading(true)
        setisError(false)
        seterrorMessage(null)
        await axios
            .post('/StringComparer/AllIndexOf', {
                text: fulltextInput,
                comparer: testtextInput
            })
            .catch(error => {
                setisError(true)
                seterrorMessage(error)
            })
            .then(response => {
                if(!response.data.success) {
                    setisError(true);
                    seterrorMessage(response.data.message);
                }else{
                    setoccurenceIndexes(response.data.data);
                    setfulltextJustSubmitted(fulltextInput)
                    settesttextJustSubmitted(testtextInput);
                    sethtmlElementOfFullText(fulltextInput.replaceAll(testtextInput, `<span class="text-black text-bold">${testtextInput}</span>`))

                    console.log(response)
                }
            })
            .finally(() => setisLoading(false))
        }
    
    useEffect(() => {
        if(isError && errorMessage) alert(errorMessage)
    },[errorMessage, isError])

    return(
        <React.Fragment>
            <h2>String Comparer</h2>
            <p className="text-caption">The string comparer help you find occurences of text within a text. It uses 2 different text, one is the full text, the other one is the comparer. It will highlight the occurences and tells you how many times the comparer text occured within the main text</p>
            <hr/>
            {
                isLoading || fulltextJustSubmitted == '' ? null :
                    <React.Fragment>
                        <h6>Full Text contains {occurenceIndexes.length} occurences {occurenceIndexes.length > 0 ? `with index ${occurenceIndexes.map((num, i) => i == occurenceIndexes.length-1 && occurenceIndexes.length > 1 ? ' and '+num+1 : num+1)}` : ''}</h6>
                        <h3 className="text-caption">{parse(htmlElementOfFullText)}</h3>
                    </React.Fragment>
            }
            <form>
                <div className="row">
                    <div className="col-md-2 hidden-sm"></div>
                    <div className="col-md-3 col-sm-4 col-12 vertical-margin-10">
                        <input type="text" placeholder="Full Text" value={fulltextInput} onInput={e => setFulltextInput(e.target.value)} required />
                    </div>
                    <div className="col-md-3 col-sm-4 col-12 vertical-margin-10">
                        <input type="text" placeholder="Comparer Text" value={testtextInput} onInput={e => setTesttextInput(e.target.value)} required />
                    </div>
                    <div className="col-md-2 col-sm-4 col-12 vertical-margin-10">
                        <button type="submit" onClick={compare} disabled={isLoading}>Find Occurences</button>
                    </div>
                    <div className="col-md-2 hidden-sm"></div>
                </div>
            </form>
        </React.Fragment>
    )
}