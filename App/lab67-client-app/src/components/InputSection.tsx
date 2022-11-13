import axios from "axios"
import { useEffect, useRef, useState } from "react"
import InputSignalApi from "../api/InputSignalApi"
import SeedApi from "../api/SeedApi"
import SignalEntity from "../interfaces/SignalEntity"
import { useAppDispatch, useAppSelector } from "../redux/hooks"
import { inputSignalActions } from "../redux/InputSignal/inputSignalReducer"
import { getInputSignal, getInputValue } from "../redux/InputSignal/inputSignalSelectors"
import { seedActions } from "../redux/SeedSignal/seedReducer"

interface InputSectionProps {

}

const InputSection: React.FC<InputSectionProps> = () => {
    const inputs = useAppSelector(getInputSignal)
    const inputValue = useAppSelector(getInputValue)
    const dispatch = useAppDispatch()

    const fetcher = {
        inputs: async () => {
            const { data } = await InputSignalApi.getAll()
            dispatch(inputSignalActions.init(data))
        }
    }

    useEffect(() => {
        fetcher.inputs()
        InputSignalApi.getAll()
    }, [])

    const handler = {
        addClick: async () => {
            const { data: inputSignal } = await InputSignalApi.create(inputValue)
            dispatch(inputSignalActions.add(inputSignal))
            await SeedApi.deleteAll()
            dispatch(seedActions.removeAll())
        },
        deleteClick: async (id: number) => {
            await InputSignalApi.delete(id)
            dispatch(inputSignalActions.remove(id))
            await SeedApi.deleteAll()
            dispatch(seedActions.removeAll())
        },
        clearClick: () => {
            dispatch(inputSignalActions.inputChange(""))
        },
        inputChange: (e: React.ChangeEvent<HTMLInputElement>) => {
            const value = e.target.value
            dispatch(inputSignalActions.inputChange(value))
        }
    }


    return (
        <section className="InputSection">
            <h2>Inputs</h2>
            <input value={inputValue} onChange={handler.inputChange} type="text" />
            <button onClick={handler.addClick}>Add</button>
            <button onClick={handler.clearClick}>Clear</button>
            <ul className="InputSection-list">
                {inputs.map(el =>
                    <li key={el.id}>
                        <div>{el.name}</div>
                        <button onClick={() => handler.deleteClick(el.id)}>Delete</button>
                    </li>
                )}
            </ul>
        </section>
    )
}

export default InputSection