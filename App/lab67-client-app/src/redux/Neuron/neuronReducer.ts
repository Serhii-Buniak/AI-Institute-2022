import { createSlice, PayloadAction } from "@reduxjs/toolkit"
import ViewSignal from "../../interfaces/ViewSignal"

interface NeuronState {
    inputs: ViewSignal[]
    outputs: ViewSignal[]
}

interface InitNeuron {
    inputs: string[],
    outputs: string[]
}

interface SetInputValueNeuron {
    name: string
    value: number
}

const initialState: NeuronState = {
    inputs: [],
    outputs: []
}

const neuronSlice = createSlice({
    name: "Neuron",
    initialState,
    reducers: {
        initNames: (state, action: PayloadAction<InitNeuron>) => {
            state.inputs = action.payload.inputs.map(el => ({ name: el, value: 0 }))
            state.outputs = action.payload.outputs.map(el => ({ name: el, value: 0 }))
        },
        setInputValue: (state, action: PayloadAction<SetInputValueNeuron>) => {
            state.inputs.forEach(p => {
                if (p.name == action.payload.name) {
                    p.value = action.payload.value
                }
            })
        },
        setOutputValues: (state, action: PayloadAction<number[]>) => {
            state.outputs.forEach((el, i) => {
                el.value = action.payload[i]
            })
        },
    }
})

export const neuronActions = neuronSlice.actions

export default neuronSlice.reducer