import instanse from "."
import Seed from "../interfaces/Seed"
import ViewSignal from "../interfaces/ViewSignal"

class NeuronApi {
    private static readonly base = "Neuron"

    teach() {
        return instanse.post(`${NeuronApi.base}`)
    }

    setInputs(viewSignals: ViewSignal[]) {
        return instanse.put<number[]>(`${NeuronApi.base}`, viewSignals)
    }
}

export default new NeuronApi()