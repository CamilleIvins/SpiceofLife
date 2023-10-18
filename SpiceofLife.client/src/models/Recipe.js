export class Recipe {
    constructor(data){
        this.id = data.id
        this.category = data.category
        this.title = data.title
        this.instructions = data.instructions
        this.img = data.img
        this.archived = data.archived
        this.creatorId = data.creatorId
        this.creator = data.creator
    }
}