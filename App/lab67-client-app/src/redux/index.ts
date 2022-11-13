import { configureStore } from '@reduxjs/toolkit'
import inputSignalReducer from './InputSignal/inputSignalReducer'
import neuronReducer from './Neuron/neuronReducer'
import outputSignalReducer from './OutputSignal/outputSignalReducer'
import seedReducer from './SeedSignal/seedReducer'

const store = configureStore({
    reducer: {
        inputSignal: inputSignalReducer,
        outputSignal: outputSignalReducer,
        seed: seedReducer,
        neuron: neuronReducer
    },
    devTools: true
})

export type AppState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch

export type AppThunkOptions = {
    state: AppState
    dispatch: AppDispatch
}

export default store