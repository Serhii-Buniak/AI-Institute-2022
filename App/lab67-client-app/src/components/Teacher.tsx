import { useAppDispatch, useAppSelector } from "../redux/hooks"
import { getInputSignal } from "../redux/InputSignal/inputSignalSelectors"
import { getNeuronInputs, getNeuronOutputs } from "../redux/Neuron/neuronSelectors"
import { neuronActions } from "../redux/Neuron/neuronReducer"
import { getOutputSignal } from "../redux/OutputSignal/outputSignalSelectors"
import NeuronApi from "../api/NeuronApi"

interface TeacherProps {

}

const Teacher: React.FC<TeacherProps> = () => {
    const dispatch = useAppDispatch()

    const inputs = useAppSelector(getInputSignal)
    const outputs = useAppSelector(getOutputSignal)

    const inputsView = useAppSelector(getNeuronInputs)
    const outputsView = useAppSelector(getNeuronOutputs)

    const handler = {
        teachClick: async () => {
            await NeuronApi.teach()
            dispatch(neuronActions.initNames({
                inputs: inputs.map(el => el.name),
                outputs: outputs.map(el => el.name),
            }))
        },
        runClick: async () => {
            const { data } = await NeuronApi.setInputs(inputsView)
            console.log(data);
            dispatch(neuronActions.setOutputValues(data))
        },
        changeInput: (value: number, name: string) => {
            dispatch(neuronActions.setInputValue({ value: value, name: name }))
        }
    }

    return (
        <section className="Teacher">
            <h2>Neuron</h2>
            <div>
                <h3>Teacher</h3>
                <button onClick={handler.teachClick}>Teach</button>
            </div>
            <div>
                <h3>Inputs</h3>
                <table>
                    <thead>
                        <tr>
                            {inputsView.map(input =>
                                <th className="TrInput" key={input.name}>{input.name}</th>
                            )}
                            <th className="TrAction">Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            {inputsView.map(input =>
                                <td key={input.name} className="TdInputSignal">
                                    <input onChange={(e) => handler.changeInput(+e.target.value, input.name)} className="input" type="number" value={input.value} />
                                </td>
                            )}
                            <td>
                                <button onClick={handler.runClick}>Run</button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div>
                <h3>Outputs</h3>
                <table>
                    <thead>
                        <tr>
                            {outputsView.map(output =>
                                <th className="TrInput" key={output.name}>{output.name}</th>
                            )}
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            {outputsView.map(output =>
                                <td key={output.name} className="TdInputSignal">
                                    {output.value}
                                </td>
                            )}
                        </tr>
                    </tbody>
                </table>
            </div>
        </section>
    )
}

export default Teacher