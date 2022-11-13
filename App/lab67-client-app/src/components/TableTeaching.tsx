import { useAppDispatch, useAppSelector } from "../redux/hooks"
import { getInputSignal } from "../redux/InputSignal/inputSignalSelectors"
import { getOutputSignal } from "../redux/OutputSignal/outputSignalSelectors"
import { Form, Field } from 'react-final-form'
import Seed from "../interfaces/Seed"
import SeedApi from "../api/SeedApi"
import { seedActions } from "../redux/SeedSignal/seedReducer"
import { useEffect } from "react"
import { getSeeds } from "../redux/SeedSignal/seedSelectors"

interface TableTeachingProps {

}

const TableTeaching: React.FC<TableTeachingProps> = () => {
    const dispatch = useAppDispatch()

    const seeds = useAppSelector(getSeeds)
    const inputs = useAppSelector(getInputSignal)
    const outputs = useAppSelector(getOutputSignal)

    const fetcher = {
        seeds: async () => {
            const { data } = await SeedApi.getAll()
            dispatch(seedActions.init(data))
        }
    }

    useEffect(() => {
        fetcher.seeds()
    }, [])

    const initialValues = {
        inputs: inputs.map(i => "0"),
        outputs: outputs.map(i => "0")
    }
    type FormType = typeof initialValues

    const handler = {
        submit: async (values: FormType) => {
            const seed: Seed = {
                id: 0,
                inputSignals: values.inputs.map(i => ({ id: 0, value: +i })),
                outputSignals: values.outputs.map(i => ({ id: 0, value: +i })),
            }
            const { data } = await SeedApi.create(seed)
            dispatch(seedActions.add(data))
        },
        deleteClick: async (id: number) => {
            await SeedApi.delete(id)
            dispatch(seedActions.remove(id))
        }
    }

    return (
        <section className="TableTeaching">
            <h2>Seeds</h2>
            <Form
                initialValues={initialValues}
                onSubmit={handler.submit}
                render={({ handleSubmit, form, submitting, pristine }) => (
                    <form onSubmit={handleSubmit}>
                        <div className="lists">
                            <div className="list">
                                <h3>Inputs</h3>
                                {inputs.map((input, i) => <div key={input.id} className="list-item">
                                    <div>{input.name}</div>
                                    <Field
                                        name={`inputs[${i}]`}
                                        component="input"
                                        type="number"
                                    />
                                </div>)}
                            </div>
                            <div className="list">
                                <h3>Outputs</h3>
                                {outputs.map((output, i) => <div key={output.id} className="list-item">
                                    <div>{output.name}</div>
                                    <Field
                                        name={`outputs[${i}]`}
                                        component="input"
                                        type="number"
                                    />
                                </div>)}
                            </div>
                        </div>
                        <div className="buttons">
                            <button type="submit" disabled={submitting}>
                                Add
                            </button>
                            <button type="reset" onClick={() => form.reset()}>
                                Clear
                            </button>
                        </div>
                    </form>
                )}
            />

            <table>
                <thead>
                    <tr>
                        {inputs.map(i =>
                            <th className="TrInput" key={"input" + i.id}>{i.name}</th>
                        )}
                        {outputs.map(o =>
                            <th className="TrOutput" key={"output" + o.id}>{o.name}</th>
                        )}
                        <th className="TrAction">Action</th>
                    </tr>
                </thead>
                <tbody>
                    {seeds.map(seed => <tr key={seed.id}>

                        {seed.inputSignals.map(input =>
                            <td key={"input" + input.id} className="TdInputSignal">
                                {input.value}
                            </td>
                        )}

                        {seed.outputSignals.map(output =>
                            <td key={"output" + output.id} className="TdOutputSignal">
                                {output.value}
                            </td>
                        )}
                        <td>
                            <button onClick={() => handler.deleteClick(seed.id)}>Delete</button>
                        </td>
                    </tr>)}

                </tbody>
            </table>
        </section>
    )
}


export default TableTeaching