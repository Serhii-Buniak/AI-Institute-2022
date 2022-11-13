import instanse from "."
import Seed from "../interfaces/Seed"

class SeedApi {
    private static readonly base = "Seed"

    getAll() {
        return instanse.get<Seed[]>(`${SeedApi.base}`)
    }

    create(seed: Seed) {
        return instanse.post<Seed>(`${SeedApi.base}`, seed)
    }

    deleteAll() {
        return instanse.delete(`${SeedApi.base}`)
    }

    delete(id: number) {
        return instanse.delete(`${SeedApi.base}/${id}`)
    }
}

export default new SeedApi()