import { useEffect } from "react"
import OutputSignalApi from "../api/OutputSignalApi"
import SeedApi from "../api/SeedApi"
import { useAppDispatch, useAppSelector } from "../redux/hooks"
import { outputSignalActions } from "../redux/OutputSignal/outputSignalReducer"
import { getOutputSignal, getOutputValue } from "../redux/OutputSignal/outputSignalSelectors"
import { seedActions } from "../redux/SeedSignal/seedReducer"

interface InputSectionProps {

}

const OutputSection: React.FC<InputSectionProps> = () => {
    const inputs = useAppSelector(getOutputSignal)
    const inputValue = useAppSelector(getOutputValue)
    const dispatch = useAppDispatch()

    const fetcher = {
        inputs: async () => {
            const { data } = await OutputSignalApi.getAll()
            dispatch(outputSignalActions.init(data))
        }
    }

    useEffect(() => {
        fetcher.inputs()
        OutputSignalApi.getAll()
    }, [])

    const handler = {
        addClick: async () => {
            const { data: inputSignal } = await OutputSignalApi.create(inputValue)
            dispatch(outputSignalActions.add(inputSignal))
            await SeedApi.deleteAll()
            dispatch(seedActions.removeAll())
        },
        deleteClick: async (id: number) => {
            await OutputSignalApi.delete(id)
            dispatch(outputSignalActions.remove(id))
            await SeedApi.deleteAll()
            dispatch(seedActions.removeAll())
        },
        clearClick: () => {
            dispatch(outputSignalActions.inputChange(""))
        },
        inputChange: (e: React.ChangeEvent<HTMLInputElement>) => {
            const value = e.target.value
            dispatch(outputSignalActions.inputChange(value))
        }
    }


    return (
        <section className="OutputSection">
            <h2>Outputs</h2>
            <input value={inputValue} onChange={handler.inputChange} type="text" />
            <button onClick={handler.addClick}>Add</button>
            <button onClick={handler.clearClick}>Clear</button>
            <ul className="OutputSection-list">
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

export default OutputSection