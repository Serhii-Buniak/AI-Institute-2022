import instanse from "."
import SignalEntity from "../interfaces/SignalEntity"

class OutputSignalApi {
    private static readonly base = "OutputSignal"

    getAll() {
        return instanse.get<SignalEntity[]>(`${OutputSignalApi.base}`)
    }

    create(name: string) {
        return instanse.post<SignalEntity>(`${OutputSignalApi.base}`, {}, {
            params: {
                name: name
            }
        })
    }

    delete(id: number) {
        return instanse.delete(`${OutputSignalApi.base}/${id}`)
    }
}

export default new OutputSignalApi()